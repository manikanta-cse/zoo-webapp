angular.module('zooApp').value('zooToastr', toastr);

angular.module('zooApp').factory('notifierService',
    function (zooToastr) {
        return {
            notify: function (msg) {
                zooToastr.success(msg);
                console.log(msg);
            },
            error: function (msg) {
                zooToastr.error(msg);
                console.log(msg);
            }
        }

    });