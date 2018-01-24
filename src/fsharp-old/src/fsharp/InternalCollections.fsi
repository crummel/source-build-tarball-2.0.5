// Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

namespace Internal.Utilities.Collections
  
  /// Simple aging lookup table. When a member is accessed it's
  /// moved to the top of the list and when there are too many elements
  /// the least-recently-accessed element falls of the end.  
  ///
  ///  - areSimilar: Keep at most once association for two similar keys (as given by areSimilar)
  type internal AgedLookup<'Token, 'Key, 'Value when 'Value : not struct> = 
    new : keepStrongly:int
            * areSimilar:('Key * 'Key -> bool) 
            * ?requiredToKeep:('Value -> bool)
            * ?onStrongDiscard : ('Value -> unit) // this may only be set if keepTotal=keepStrongly, i.e. not weak entries
            * ?keepMax: int
            -> AgedLookup<'Token,'Key,'Value>
    /// Lookup the value without making it the most recent.
    /// Returns the original key value because the areSame function
    /// may have unified two different keys.
    member TryPeekKeyValue : 'Token * key:'Key -> ('Key*'Value) option
    /// Lookup a value and make it the most recent.
    /// Returns the original key value because the areSame function
    /// may have unified two different keys.
    member TryGetKeyValue : 'Token * key: 'Key -> ('Key*'Value) option    
    /// Lookup a value and make it the most recent. Return <c>None</c> if it wasn't there.
    member TryGet : 'Token * key:'Key -> 'Value option        
    /// Add an element to the collection. Make it the most recent.
    member Put : 'Token * 'Key * 'Value -> unit
    /// Remove the given value from the collection.
    member Remove : 'Token * key:'Key -> unit
    /// Remove all elements.
    member Clear : 'Token -> unit
    /// Resize
    member Resize : 'Token * keepStrongly: int * ?keepMax : int -> unit
    
  /// Simple priority caching for a small number of key/value associations.
  /// This cache may age-out results that have been Set by the caller.
  /// Because of this, the caller must be able to tolerate values 
  /// that aren't what was originally passed to the Set function.     
  ///
  /// Concurrency: This collection is thread-safe, though concurrent use may result in different
  /// threads seeing different live sets of cached items, and may result in the onDiscard action
  /// being called multiple times. In practice this means the collection is only safe for concurrent
  /// access if there is no discard action to execute.
  ///
  ///  - areSimilar: Keep at most once association for two similar keys (as given by areSimilar)
  type internal MruCache<'Token, 'Key,'Value when 'Value : not struct> =
    new : keepStrongly:int 
            * areSame:('Key * 'Key -> bool) 
            * ?isStillValid:('Key * 'Value -> bool)
            * ?areSimilar:('Key * 'Key -> bool) 
            * ?requiredToKeep:('Value -> bool)
            * ?onDiscard:('Value -> unit)
            * ?keepMax:int
            -> MruCache<'Token,'Key,'Value>

    /// Clear out the cache.
    member Clear : 'Token -> unit

    /// Get the similar (subsumable) value for the given key or <c>None</c> if not already available.
    member ContainsSimilarKey : 'Token * key:'Key -> bool

    /// Get the value for the given key or <c>None</c> if not still valid.
    member TryGetAny : 'Token * key:'Key -> 'Value option

    /// Get the value for the given key or None, but only if entry is still valid
    member TryGet : 'Token * key:'Key -> 'Value option

    /// Remove the given value from the mru cache.
    member RemoveAnySimilar : 'Token * key:'Key -> unit

    /// Set the given key. 
    member Set : 'Token * key:'Key * value:'Value -> unit

    /// Resize
    member Resize : 'Token * keepStrongly: int * ?keepMax : int -> unit

  [<Sealed>]
  type internal List = 
    /// Return a new list with one element for each unique 'Key. Multiple 'TValues are flattened. 
    /// The original order of the first instance of 'Key is preserved.
    static member groupByFirst : l:('Key * 'Value) list -> ('Key * 'Value list) list when 'Key : equality
    /// Return each distinct item in the list using reference equality.
    static member referenceDistinct : 'T list -> 'T list when 'T : not struct
