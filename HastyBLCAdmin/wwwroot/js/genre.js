var jq = jQuery.noConflict();
jq(document).ready(function () {
    jq("#addGenreBtn").click(function () {
        jq("#myModal").modal("show");
    });
});
