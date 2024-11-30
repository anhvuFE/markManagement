var connection = new signalR.HubConnectionBuilder().withUrl("/documentHub").build();

connection.on("ReloadDocuments", function () {
    //yeu cau page load lai du lieu
    location.reload();
});

connection.start().then(
).catch(
    function (err) {
        return console.error(err.toString());
    }
);