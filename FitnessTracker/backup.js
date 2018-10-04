var userInput = {
};
var userList = [];
var daysOfTheWeek = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"]; 
var currentDay = daysOfTheWeek[0];

var views = {
    displayExercises: () => {document.className = "";document.classList.Add("exercises");},
    displayDay: () => currentDay,
    displayGraph: () => userInput[0],
    displayExercises: () => userInput[0],
    displayExercises: () => userInput[0],
};

var controllers = {
    addExercise: () => bongo,
    addUser: () => bongo,
    addWorkout: () => bongo,
    

};
var models = {
    user = {
        id: userList.length - 1,
        firstName: userInput,
        lastName: userInput,
        weight: userInput,
        height: userInput,
        phoneNumber: userInput,
        email: userInput,
        birthday: userInput,
        gender: userInput,
        add: function(){
            userList.push(this);
        },
        getAll: () => userList,
        deleteAll: () => userList = [],
        delete: () => {
            userList = userList.splice(this.id, this.id + 1); 
        },
        clearAll: () => {
            userList = []; 
        }
    },
    exercise = {
        id: this.length - 1,
        name: userInput,
        add: function(){
            workout.exerciseList.push(this.name);
        },
        getAll: function(){

        },
        delete: function() {

        },
        clearAll: function() {

        }
    },
    workout = {
        id: this.length - 1,
        name: userInput,
        exerciseList: [],
        add: function() {
        
        },
        getAll: function() {

        },
        delete: function() {

        },
        clearAll: function() {

        }
    },

};


