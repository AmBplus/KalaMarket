function changeStatus(id) {
    $.ajax({
        url: `RemovedUsers/ChangeStatus?id=${id}`,
        method: "Put",
        contentType: `application/json; charset=utf-8`,
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $(`input:hidden[name="__RequestVerificationToken"]`).val());
        },
    }).done(function (result) {
        Swal.fire({
            icon: 'success',
            title: 'وضعیت کاربر انتخاب شده\n تغیر پیدا کرد',
            timer: 2500,
            confirmButtonColor: '#3085d6',
        }).then(() => {
            location.reload(true)
        });

    }).fail(function (result) {
        Swal.fire({
            //icon: 'question',
            icon: "error",
            html: `<h4 class="text-danger">${result.responseJSON.message}</h4>`,
            showCloseButton: true,
            confirmButtonText: "بستن",
            confirmButtonColor: '#3085d6',
        })
    });
}