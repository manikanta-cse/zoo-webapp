angular.module('zooApp').factory('utilService',
    function () {

        var getCurrentYear = function () {

            var today = new Date();
            return today.getFullYear();
        };


        var calulateAge = function (yearOfBirth) {

            return getCurrentYear() - yearOfBirth;

        };


        return {
            calulateAge: calulateAge
            
        }

    });