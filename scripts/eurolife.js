"use strict";
var xml2js = require("xml2js");
var fs = require("fs");

var eurolife = {};

eurolife.getConfiguration = function getConfigFile(filename) {
  var data = fs.readFileSync(filename);

  var parser = new xml2js.Parser();
  var content;
  parser.parseString(data, function (err, result) {
    if (err !== null) throw err;
    content = result;
  });
  return content;
};

eurolife.getSiteUrl = function getSiteUrl(options) {
  if (!options) options = {};

    var publishFile = options.publishingSettingsFile ? options.publishingSettingsFile : eurolife.getPublishingSettingsFile();
  try {
    var configuration = eurolife.getConfiguration(publishFile);
    return configuration.Project.PropertyGroup[0].publishUrl[0];
  } catch(error) {
    error.message = "Could not get the Eurolife site URL from '" + publishFile + "'. Error:" + error.message;
    throw(error);
  }
};

eurolife.getPublishingSettingsFile = function getPublishingSettingsFile() {
    if (fs.existsSync("./publishsettings.targets.user"))
        return "./publishsettings.targets.user";
    return "./publishsettings.targets";
}

module.exports = eurolife;