let user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            Swal.fire({
                title: 'Are you sure?',
              /*  text: "You won't be able to revert this!",*/
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        url: "/Admin/PostAdmin/ChangeStatus",
                        data: { id: id },
                        dataType: "json",
                        type: "POST",
                        success: function(response) {
                            console.log(response);
                            if (response.status == true) {
                                btn.text('Approved');
                            } else {
                                btn.text('Not approved yet');
                            }
                        }, err: function(e) {
                            Swal.fire(
                                'Error.'
                            );
                        }
                    });
                    Swal.fire(
                        'Success!'
                    );
                }
            });
        });
    }
}
user.init();