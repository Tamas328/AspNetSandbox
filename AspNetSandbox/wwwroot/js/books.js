"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

connection.start().then(function () {
    console.log("Connection established.");
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("AddedBook", (book) => {
    console.log("Book added: " + JSON.stringify(book));
    $("tbody")[0].append(`<tr>
        <td>
            ${book.title}added
        </td>
        <td>
            ${book.author}
        </td>
        <td>
            ${book.language}
        </td>
        <td>
            <a href="/Books/Edit?id=${book.id}">Edit</a> |
            <a href="/Books/Details?id=${book.id}">Details</a> |
            <a href="/Books/Delete?id=${book.id}">Delete</a>
        </td>
    </tr>`)
});

connection.on("EditedBook", (book) => {
    console.log("Edited book: " + JSON.stringify(book));
});

connection.on("DeletedBook", (book) => {
    console.log("Deleted book: " + JSON.stringify(book));
});