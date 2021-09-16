"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

connection.start().then(function () {
    console.log("Connection established.");
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("AddedBook", (book) => {
    console.log("Book added: " + JSON.stringify(book));
    var row = `<tr id=book-${book.id}>
        <td>
            ${book.title}
        </td>
        <td>
            ${book.author}
        </td>
        <td>
            ${book.language}
        </td>
        <td>
            <a href="/Books/Edit?id=${book.id}" class="btn btn-secondary">Edit</a>
            <a href="/Books/Details?id=${book.id}" class="btn btn-info">Details</a>
            <a href="/Books/Delete?id=${book.id}" class="btn btn-danger">Delete</a>
        </td>
    </tr>`;
    $("#tbody")[0].innerHTML += row;
});

connection.on("EditedBook", (book) => {
    console.log("Edited book: " + JSON.stringify(book));
    var row = document.getElementById(`book-${book.id}`);
    row.innerHTML = `<tr id=book-${book.id}>
        <td>
            ${book.title}
        </td>
        <td>
            ${book.author}
        </td>
        <td>
            ${book.language}
        </td>
        <td>
            <a href="/Books/Edit?id=${book.id}" class="btn btn-secondary">Edit</a>
            <a href="/Books/Details?id=${book.id}" class="btn btn-info">Details</a>
            <a href="/Books/Delete?id=${book.id}" class="btn btn-danger">Delete</a>
        </td>
    </tr>`;
});

connection.on("DeletedBook", (book) => {
    console.log("Deleted book: " + JSON.stringify(book));
    var row = document.getElementById(`book-${book.id}`);
    row.parentNode.removeChild(row);
});