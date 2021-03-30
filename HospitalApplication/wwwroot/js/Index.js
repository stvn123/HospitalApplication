$(document).ready(function () {
    var diagnosis = {
        illnessId: null,
        illnessName: null,
        patientName: null,
        levelOfPain: null
    };

    $('#detailModal').on('show.bs.modal', function (event) {
        var modalData = $(event.relatedTarget);
        diagnosis.illnessName = modalData.data('illness').name;
        diagnosis.illnessId = modalData.data('illness').id;   
        $("#illnessName").text(diagnosis.illnessName);
    })

    $('input:radio[name="illnessLevel"]').change(function () {
        if ($(this).is(':checked')) {
            illness.levelOfPain = $(this).val();
        }
    });

    $('#btnOK').click(function () {
        diagnosis.patientName = $("#patientName").val();
        $('#detailModal').modal('hide');
        getHospitals(diagnosis);
    });
});


function getHospitals(diagnosis) {
    $.ajax({
        url: '/Home/GetHospitals',
        type: 'POST',
        data: diagnosis,
        success: function (response) {
            window.location.href = response.redirectToUrl;
        },
    });
}