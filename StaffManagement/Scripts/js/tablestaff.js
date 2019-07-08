$(document).ready(function () {
    $(".edit-item-link").on("click", function(e) {
        e.preventDefault();
        const employeeId = $(this).data("id");
            
        $.ajax({
            type: "POST",
            url: "/Home/ShowDialogEmployee",
            data: { employeeId },
            success: function(result) {
                $("#dialogcontext").html(result);

                return $("#dg-new-user-modal").modal("show");
            }
        }).fail(function() {
            alert("Error");
        });
    });
});