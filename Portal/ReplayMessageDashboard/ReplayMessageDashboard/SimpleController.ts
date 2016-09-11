/// <reference path="app.ts" />
/// <reference path="Scripts/angular.d.ts" />


class SimpleController {
    private http: any;
    // Dependency injection via construstor
    constructor($scope: ng.IScope, $http: ng.IHttpService) {
        this.http = $http;
    }

    public header: string = 'Welcome!';
    public savingUpFor: string = 'Welcome!';
    public text: string = 'Use Price & Cost to control your project\'s budget!';
    public tips: string[] = ['be efficient', 'be successful', 'be happy'];

    public signUpNow() {
        this.http.get("https://savings-tracker.firebaseio.com/settings.json").then(
            response => {
                this.header = response.data.savingUpFor;
            });
        
      //  window.location.href = "http://www.priceandcost.com";
    };


    
}

angular.module('myApp').controller(
    'SimpleController', SimpleController);