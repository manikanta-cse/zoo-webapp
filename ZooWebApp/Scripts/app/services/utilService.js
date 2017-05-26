(function() {

    angular.module('zooApp').factory('utilService', utilService);

    function utilService() {

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

    }

})();

