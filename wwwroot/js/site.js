"use strict";

// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let message = $('#chat-asp-input').val();

let chat = $('#chat-asp-content');
chat.scrollTop(chat.prop("scrollHeight"));

$('#chat-asp-input').on("keyup", messageListener);

$('#chat-asp-send-message-button').on('click', async event => {
    try {
        let message = $('#chat-asp-input').val();

        if(message.length > 0) {
            $('#chat-asp-input').val('');
            $('#chat-asp-send-message-button').css({color: 'teal'})

            let response = await sendMessageRequest(message);
            
            $("#chat-asp-content").append(`<div class="message me">
                <div class="message-content">${response.content}</div>
                <div class="message-time">${response.createdAt}</div>
            </div>`)

            chat.scrollTop(chat.prop("scrollHeight"));

        }
    } catch (error) {
        console.error(error);
    }
})

async function messageListener(event) {
    try {
        if(event.target.value.length > 0) {
            $('#chat-asp-send-message-button').css({color: "teal"})
        } else {
            $('#chat-asp-send-message-button').css({color: 'grey'})
        }

        if(event.keyCode == 13 && event.target.value.length > 0) {
            let message = event.target.value;
            event.target.value = '';
            $('#chat-asp-send-message-button').css({color: 'grey'});
            let response = await sendMessageRequest(message);
            chat.append(`<div class="message me">
                <div class="message-content">${response.content}</div>
                <div class="message-time">${response.createdAt}</div>
            </div>`);
            chat.scrollTop(chat.prop("scrollHeight"));

        }
    } catch (error) {
        console.error(error);
    }    
}

const connection =  new signalR
    .HubConnectionBuilder()
    .withUrl("/chat")
    .build();

connection.start()
.then(() => console.log("connected"))
.catch(() => console.log("not connected"));

async function sendMessageRequest(content) {
    let body = {
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          },
        
        method:"POST",
        body: JSON.stringify({ Content: content })
    };

    return await fetch(window.location.origin + "/api/message", body)
        .then(res => res.json());
}

connection.on("ReceiveMessage", (messageJson) => {
    
    let chat = $('#chat-asp-content');

    let message = JSON.parse(messageJson);

    console.log(message.UserId, $("#IdUser").val(), message.UserId !== $("#IdUser").val())

    if(message.UserId !== $("#IdUser").val()){
        console.log("caiu")
        console.log(message)
        chat.append(`<div class="message else">
            <div class="message-user">${message.UserName}</div>
            <div class="message-content">${message.Content}</div>
            <div class="message-time">${message.CreatedAt}</div>
        </div>`);

        chat.scrollTop(chat.prop("scrollHeight"));

    }
})

