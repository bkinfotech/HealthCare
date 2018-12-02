$(function () {
    setTimeout(function () {
        ajaxRequest('GET', '/Doctor/GetDoctorsList', null, 'html').then(function (result) {        
        $('#doctor-partialview').html(result);
    }, function (reason) {
        console.log("error in processing your request", reason);
            })
        , 50000
    })

    ajaxRequest('GET', '/Specialization/GetSpecializations', null, 'html').then(function (result) {
        console.log('Success ' + result);
        $('#specialization-partialView').html(result);
    }, function (reason) {
        console.log("error in processing your request", reason);
    });

    //$('#btn-search-doctor').click(function () {
    //    ajaxRequest('GET', '/Dashboard/Test', null, 'html').then(function (result) {
    //        console.log('Success ' + result);
    //        $('#doctor-partialview').html(result);
    //    }, function (reason) {
    //        console.log("error in processing your request", reason);
    //    });
    //});
    $('input=[checkbox]').change(function myfunction() {
        alert('changed');
    });
});
