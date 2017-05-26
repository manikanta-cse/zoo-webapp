(function() {

    angular.module('zooApp').factory('mapperService',mapperService);


    function mapperService() {
        var mapModelToViewModel = function (animal) {
            var animalViewModel = {};
            if (animal) {

                animalViewModel.animalName = animal.AnimalName;
                animalViewModel.species = { SpeciesId: animal.SpeciesId };
                animalViewModel.animalId = animal.AnimalId || 0;
                animalViewModel.yearOfBirth = animal.YearOfBirth;
                animalViewModel.age = animal.Age;
                animalViewModel.addedDatetime = animal.AddedDateTime;
                animalViewModel.modifiedDatetime = animal.ModifiedDatetime || null;
            }

            return animalViewModel;

        }

        var mapViewModelToModel = function (animal) {
            var animalModel = {};
            if (animal) {
                animalModel.animalName = animal.animalName;
                animalModel.speciesId = animal.species.SpeciesId;
                animalModel.animalId = animal.animalId || 0;
                animalModel.yearOfBirth = animal.yearOfBirth;
            }

            return animalModel;



        };

        return {
            mapModelToViewModel: mapModelToViewModel,
            mapViewModelToModel: mapViewModelToModel
        }
    }

})();

