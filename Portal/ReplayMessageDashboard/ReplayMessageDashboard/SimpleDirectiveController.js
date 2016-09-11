///// <reference path="../../typings/angularjs/angular.d.ts" />
///// <reference path="SimpleClickCountService.ts" />
//class SimpleDirectiveController {   
//    // This is the initializer that we will pass to AngularJS.
//    public static initializer: ng.IDirectiveFactory = (simpleClickCountService: SimpleClickCountService) => {
//        return {
//            controller: () => new SimpleDirectiveController(simpleClickCountService),
//            controllerAs: 'simpleDirective',
//            scope: {},
//            templateUrl: 'SimpleStuff/SimpleDirective.html'
//        };
//    };
//    // Keep our Angular dependencies as a static variable
//    public static AngularDependencies: any[] = [
//        'SimpleClickCountService',
//        SimpleDirectiveController.initializer];
//    private _simpleClickCountService: SimpleClickCountService
//    public constructor(simpleClickCountService: SimpleClickCountService) {
//        this._simpleClickCountService = simpleClickCountService;
//    }
//    public message: string = 'Hello from SimpleDirective!';
//    public getButtonText(): string {
//        var count = this._simpleClickCountService.GetClickCount();
//        if (count == 0) return 'Click me!';
//        else return 'You clicked me ' + count + ' times!';
//    }
//    public clickMe(): void {
//        this._simpleClickCountService.Increment();
//    }
//}
//myApp.directive('myAppSimpleDirective', SimpleDirectiveController.AngularDependencies);
//    export class HomeController {
//        app: ng.IModule;
//        constructor(name: string, modules: Array<string>) {
//            this.app = angular.module(name, modules);
//        }
//        addController(name: string, controller: Function) {
//            this.app.controller(name, controller);
//        }
//        public Welcome = (): string => {
//            return "Welcome to the dashboard";
//        };
//    }
//angular.module("app").service("HomeController", app.HomeController);
//angular.module('replayDashboard', [])
//    .controller('HomeController', function () {
//        var todoList = this;
//        todoList.todos = [
//            { text: 'learn angular', done: true },
//            { text: 'build an angular app', done: false }];
//        todoList.addTodo = function () {
//            todoList.todos.push({ text: todoList.todoText, done: false });
//            todoList.todoText = '';
//        };
//        todoList.remaining = function () {
//            var count = 0;
//            angular.forEach(todoList.todos, function (todo) {
//                count += todo.done ? 0 : 1;
//            });
//            return count;
//        };
//        todoList.archive = function () {
//            var oldTodos = todoList.todos;
//            todoList.todos = [];
//            angular.forEach(oldTodos, function (todo) {
//                if (!todo.done) todoList.todos.push(todo);
//            });
//        };
//        todoList.Welcome = function () {
//            return "Welcome to the dashboard";
//        };
//    }); 
//# sourceMappingURL=SimpleDirectiveController.js.map