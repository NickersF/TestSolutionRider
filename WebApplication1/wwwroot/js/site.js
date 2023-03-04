// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let a = "Meow";

function meow() {
    console.log("meow");
}

meow();

$("#Meow").on("click", (e) => {
    console.log(e);
    $("#Meow").removeClass("btn-primary").addClass("btn-danger");
    
    $.ajax({
        type: "GET",
        global: false,
        url: "/Home/GetModelProps"
    }).then((data) => {
        let parsedModelProps = JSON.parse(data);
        console.log(data);
        console.log(parsedModelProps);
    });
});

class Cat {
    constructor(name, breed, age, color) {
        this.name = name;
        this.breed = breed;
        this.age = age;
        this.color = color;
        this.hunger = 0;
        this.happiness = 100;
    }

    meow() {
        console.log(`${this.name} meows.`);
    }

    sleep() {
        console.log(`${this.name} is sleeping.`);
    }

    eat(food) {
        console.log(`${this.name} is eating ${food}.`);
        this.hunger -= 10;
        this.happiness += 5;
    }

    play() {
        console.log(`${this.name} is playing.`);
        this.happiness += 10;
    }

    status() {
        console.log(`${this.name}'s hunger level is ${this.hunger} and happiness level is ${this.happiness}.`);
    }
}
