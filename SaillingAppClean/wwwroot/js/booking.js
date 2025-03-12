var dataTable;

$(document).ready(function () {
    const urlParams = new URLSearchParams(window.location.search);
    const status = urlParams.get('status');
    loadDataTable(status);
});

function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/booking/getall?status=' + status },
        "columns": [
            { data: 'id', "width": "10%" },
            { data: 'name', "width": "10%" },
            { data: 'phoneNumber', "width": "10%" },
            { data: 'email', "width": "10%" },
            { data: 'status', "width": "10%" },
            { data: 'checkInDate', "width": "10%" },
            { data: 'nights', "width": "10%" },
            { data: 'totalCost', render: $.fn.dataTable.render.number(',', '.', 2), "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group">
                        <a href="/booking/bookingDetails?bookingId=${data}" class="btn btn-outline-warning mx-2">
                            <i class="bi bi-info-circle"></i> Details
                        </a>
                    </div>`;
                },
                "width": "20%"
            }
        ]
    });
}
