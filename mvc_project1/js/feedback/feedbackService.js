(function(){

'use strict';

var FeedbackService = function ($q, $http) {
    var service = {}

    service.postFeedback = postFeedback;
    service.getFeedback = getFeedback;
     


    function postFeedback(feedback) {
        console.log("Post Feedback:" + feedback);
        var deferred = $q.defer();

        $http.post("/api/Feedback", feedback).then(function (response) {
           deferred.resolve(response);
        },
           function () {
               deferred.reject("Issue posting feedback data");
           });;
        return deferred.promise;
    }

    function getFeedback() {
        console.log("getFeedback.REST call");
        var deferred = $q.defer();
          $http.get("/api/Feedback").then(function (data) {
                deferred.resolve(data);
          },
           function () {
               deferred.reject("Issue gathering feedback data");
           });;

        return deferred.promise;

    }

    return service;
}



angular.module('app').service('feedbackService',  FeedbackService);



})()