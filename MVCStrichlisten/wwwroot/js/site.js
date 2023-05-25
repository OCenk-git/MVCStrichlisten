$(".settings").on('click', function ()
{
    console.log($(this).val());
    console.log($(this).data("name"));

    $("#userId").val($(this).val());
    $("#userName").val($(this).data("name"));

});

$("#closeModal").on('click', function ()
{
    $("#ModalForm").modal('hide');
});