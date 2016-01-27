//Fonction d'aperçu de l'image uploader lors de l'edition d'un album
$(function () {
    // A chaque sélection de fichier
    $('#formEditAlbums').find('input[name="pochetteUpload"]').on('change', function (e) {
        var files = $(this)[0].files;

        if (files.length > 0) {
            // On part du principe qu'il n'y qu'un seul fichier
            // étant donné que l'on a pas renseigné l'attribut "multiple"
            var file = files[0],
                $image_preview = $('#image_preview');

            // Ici on injecte les informations recoltées sur le fichier pour l'utilisateur
            $image_preview.find('.thumbnail').removeClass('hidden');
            $image_preview.find('img').attr('src', window.URL.createObjectURL(file));
            $image_preview.find('h4').html(file.name);
            $image_preview.find('.caption p:first').html(file.size + ' bytes');
        }
    });

    // Bouton "Annuler" pour vider le champ d'upload
    $('#image_preview').find('button[type="button"]').on('click', function (e) {
        e.preventDefault();

        $('#formEditAlbums').find('input[name="pochetteUpload"]').val('');
        $('#image_preview').find('.thumbnail').addClass('hidden');
    });
});




//$(function () {
//    $('#formEditAlbums').on('submit', function (e) {
//        // On empêche le navigateur de soumettre le formulaire
//        e.preventDefault();

//        var $form = $(this);
//        var formdata = (window.FormData) ? new FormData($form[0]) : null;
//        var data = (formdata !== null) ? formdata : $form.serialize();

//        $.ajax({
//            url: $form.attr('action'),
//            type: $form.attr('method'),
//            contentType: false, // obligatoire pour de l'upload
//            processData: false, // obligatoire pour de l'upload
//            dataType: 'json', // selon le retour attendu
//            data: data,
//            success: function (response) {
//                // La réponse du serveur
//            }
//        });
//    });
//});