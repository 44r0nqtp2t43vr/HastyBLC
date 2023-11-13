var jq = jQuery.noConflict();
jq(document).ready(function () {
    jq(".editRoleBtn").click(function () {
        var roleId = $(this).data("role-id");
        var roleName = $(this).data("role-name");

        $("#editRoleId").val(roleId);
        $("#editRoleName").val(roleName);

        jq("#editRoleModal").modal("show");
    });
});
