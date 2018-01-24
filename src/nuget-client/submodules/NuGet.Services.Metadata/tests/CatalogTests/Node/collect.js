
var http = require('http');

var fetchItem = function (pageItem, index, callback) {
  if (pageItem.length == index) {
    callback();
    return;
  }
  var req = http.get(pageItem[index]['@id'], function (res) {
    var data = '';
    res.on('data', function (chunk) {
      data += chunk;
    });
    res.on('end', function () {
      //console.log(data);

      console.log(JSON.parse(data)['@id']);

      fetchItem(pageItem, index + 1, callback);
    });
  });
  req.on('error', function(e) {
    console.log("Got error: " + e.message);
  });
}

var fetchPage = function (indexItem, index, callback) {
    debugger;
  if (indexItem.length == index) {
    callback();
    return;
  }
  var req = http.get(indexItem[index]['@id'], function (res) {
    var data = '';
    res.on('data', function (chunk) {
      data += chunk;
    });
    res.on('end', function () {
      var page = JSON.parse(data);
      fetchItem(page.items, 0, function () {
        fetchPage(indexItem, index + 1, callback);
      });
    });
  });
  req.on('error', function(e) {
    console.log("Got error: " + e.message);
  });
}

var fetchIndex = function (address, callback) {
  var req = http.get(address, function (res) {
    var data = '';
    res.on('data', function (chunk) {
      data += chunk;
    });
    res.on('end', function () {
      var index = JSON.parse(data);
      fetchPage(index.items, 0, function () {
        callback();
      });
    });
  });
  req.on('error', function(e) {
    console.log("Got error: " + e.message);
  });
}

fetchIndex('http://nugetjohtaylo.blob.core.windows.net/ver38/catalog/index.json', function () {
  console.log('...');
});
