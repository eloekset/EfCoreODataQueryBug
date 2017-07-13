module EfCoreODataQueryBug {
    export var userCulture: string;
    export var homeVm: EfCoreODataQueryBug.HomeViewModel;
}

$(document).ready(function () {
    var options = <EfCoreODataQueryBug.HomeViewModelOptions>{
        baseUri: $("#baseUri").attr("content")
    };
    $.ajaxSetup({ cache: false }); // globally sets no-cache for all AJAX calls in this application
    EfCoreODataQueryBug.userCulture = 'en';
    Globalize.locale(EfCoreODataQueryBug.userCulture);
    EfCoreODataQueryBug.homeVm = new EfCoreODataQueryBug.HomeViewModel(options);
    ko.applyBindings(EfCoreODataQueryBug.homeVm, $("#contentDiv")[0]);
});