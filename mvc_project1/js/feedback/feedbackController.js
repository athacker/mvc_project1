(function(){

'use strict';

angular.module('app').controller('feedbackController', function ($scope, feedbackService) {

    var vm = this;

    vm.feedback = [];
    vm.newFeedback={id:null, commentDate: null, user:null, comment: null};
    vm.initForm = initForm;
    vm.getFeedback = getFeedback;
    vm.postFeedback = postFeedback;




    function initForm() {
        vm.getFeedback();
     }

    function getFeedback() {

        feedbackService.getFeedback().then(function (response) {
            console.log(JSON.stringify(response));
            vm.feedback = response["data"];

        }, function () {
            console.log("Error getting feedback data " + data)

        });


    }


    function postFeedback() {
         
        feedbackService.postFeedback(vm.newFeedback).then(function (response) {
            vm.getFeedback();
        }, function () {
            console.log("Error posting feedback data "  )
        });
    }





});




})()