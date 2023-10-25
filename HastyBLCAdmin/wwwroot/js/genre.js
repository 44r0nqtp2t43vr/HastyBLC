var jq = jQuery.noConflict();
jq(document).ready(function () {
    jq("#addGenreBtn").click(function () {
        jq("#addGenreModal").modal("show");
    });
    jq(".editGenreBtn").click(function () {
        var genreId = $(this).data("genre-id");
        var genreName = $(this).data("genre-name");

        $("#editGenreId").val(genreId);
        $("#editGenreName").val(genreName);

        jq("#editGenreModal").modal("show");
    });
    jq(".deleteGenreBtn").click(function () {
        var genreId = $(this).data("genre-id");

        $("#deleteGenreId").val(genreId);

        jq("#deleteGenreModal").modal("show");
    });
});
