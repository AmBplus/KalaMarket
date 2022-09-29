﻿
$(function () {
    $('#editUserModal').on('show.bs.modal', function (event) {
        var modal = $(this);
        var button = $(event.relatedTarget);
        var id = button.data('id');
        var fullName = button.data('fullname');
        $("#ModalUserId").val(id);
        $("#ModalUserFullName").val(fullName);
    })
})
function EditUser() {
    var userId = $("#ModalUserId").val();
    var fullNames = $("#ModalUserFullName").val();
    var editUserDto = {
        "id": userId, "FullName": fullNames
    }
    var myModal = $("#editUserModal");
    myModal.modal("hide");
    $.ajax({
        url: "/api/Admin/User",
        method: "Put",
        data: JSON.stringify(editUserDto),
        contentType: 'application/json'
    }).done((result) => {
        Swal.fire({
            icon: "success",
            title: result.message,
            showCloseButton: true,
            showConfirmButton: true,
            focusConfirm: false,
            confirmButtonText: "باشه",
            customClass: {
                confirmButton: "btn btn-success  mx-2",
            },
            buttonsStyling: false,
            timer: 4500
        }).then(() => {
            location.reload();
        })
    }).fail((result) => {
        Swal.fire({
            icon: "error",
            title: result.responseJSON.message,
            showCloseButton: true,
            showConfirmButton: true,
            confirmButtonText: "باشه",
            customClass: {
                confirmButton: "btn btn-danger  mx-2",
            },
            buttonsStyling: false,
        });
    });
}