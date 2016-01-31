$(function () {
    function RemoveClick() {
        // Get the id from the link
        var tr = $(this).parent().parent();
        var title = tr.find("#titre").html();
        var artist = tr.find("#artist").html();
        var idToDelete = tr.attr("id");

        if (idToDelete != '' && confirm('Voulez-vous supprimer l\'album:' + title + '(' + artist + ') de votre panier ? ')) {
            // Perform the ajax post
            $.post("/Carts/RemoveFromCart", { "id": idToDelete },
            function (data) {
                // Successful requests get here
                // Update the page elements
                if (data.DeleteId != 0) {
                    $('#' + data.DeleteId).fadeOut('slow');
                }
                $('#update-message').text(data.Message);
                $('#update-message').show('slow', null).delay(3000).hide('slow');
            });
        }
    };

    // Document.ready -> link up remove event handler
    $('a[name=deleteCart]').bind('click', RemoveClick);
});
