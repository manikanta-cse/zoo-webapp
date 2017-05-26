
(function() {

    angular.module('zooApp').factory('speciesService', speciesService);


    function speciesService($http, $q) {


        var getSpecies = function() {

            var defered = $q.defer();

            $http.get('/api/services/zoo/species').then(function(response) {

                    defered.resolve(response.data);

                },
                function(error) {
                    defered.reject(error.data);
                });

            return defered.promise;
        };


        return {
            getSpecies: getSpecies
        }
    }
})();

