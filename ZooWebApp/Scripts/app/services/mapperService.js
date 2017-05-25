﻿angular.module('zooApp').factory('mapperService',
    function () {
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
                animalModel.addedDatetime = animal.addedDatetime;
                animalModel.modifiedDatetime = animalModel.animalId!==0 ? animal.modifiedDatetime : null;
            }

            return animalModel;



        };

        return {
            mapModelToViewModel: mapModelToViewModel,
            mapViewModelToModel: mapViewModelToModel
        }
    })