function Delete(url) {
    const userConfirmed = confirm("Are you sure? This action cannot be undone!");

    if (userConfirmed) {
        // If the user confirms, proceed with the AJAX DELETE request
        $.ajax({
            url: url,
            type: 'DELETE',
            success: function (data) {
                // Reload the DataTable if it exists
                location.reload();
                // Show a success notification
                toastr.success(data.message || "Item deleted successfully!");
            },
            error: function (xhr, status, error) {
                // Show an error notification
                toastr.error(xhr.responseJSON?.message || "Failed to delete the item. Please try again.");
            }
        });
    }
}
