var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/ship/getall' },
        "columns": [
            { data: 'name', "width": "10%" },
            { data: 'capacity', "width": "10%" },
            { data: 'homePort', "width": "10%" },
            { data: 'lastMaintenanceDate', "width": "10%" },
            { data: 'category.name', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                                <a href="/ship/upsert?id=${data}" class="btn btn-primary mx-2">  <i class="bi bi-pencil-square"></i> Edit </a>
                                <a onClick=Delete('/ship/delete?id=${data}') class="btn btn-danger mx-2">  <i class="bi bi-trash3"></i> Delete </a>
                            </div>
                    `
                },
                "width": "10%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "This action cannot be undone!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (typeof dataTable !== "undefined") {
                        dataTable.ajax.reload();
                    }
                    toastr.success(data.message || "Item deleted successfully!");
                },
                error: function (xhr, status, error) {
                    toastr.error(xhr.responseJSON?.message || "Failed to delete the item. Please try again.");
                }
            });
        }
    });
}
