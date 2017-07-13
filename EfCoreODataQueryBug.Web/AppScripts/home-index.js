var EfCoreODataQueryBug;
(function (EfCoreODataQueryBug) {
})(EfCoreODataQueryBug || (EfCoreODataQueryBug = {}));
$(document).ready(function () {
    var options = {
        baseUri: $("#baseUri").attr("content")
    };
    $.ajaxSetup({ cache: false }); // globally sets no-cache for all AJAX calls in this application
    EfCoreODataQueryBug.userCulture = 'en';
    Globalize.locale(EfCoreODataQueryBug.userCulture);
    EfCoreODataQueryBug.homeVm = new EfCoreODataQueryBug.HomeViewModel(options);
    ko.applyBindings(EfCoreODataQueryBug.homeVm, $("#contentDiv")[0]);
});
//# sourceMappingURL=home-index.js.map