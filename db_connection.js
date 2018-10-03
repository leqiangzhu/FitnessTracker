var mysql = require('mysql');

var con = mysql.createConnection({
    host: "localhost",
    user: "root",
    password: "root",
    port: "8889",
    database: "fitness"
});




var userList = [];

const commands = {


} 
con.connect(function (err) {
    if (err) throw err;
    console.log("Connected!");
    let addCommand = function(){
        con.query(sqlCommand, function(err, result) {
        if (err) throw err;
        console.log("User Data: ");
        for (let i = 0; i < result.length; i++)
        {
            userList.push(result[i]);
        }
        console.log(userList); 
        let currentUser = userList[0];
        console.log("current user info: ");
        for (var prop in currentUser)
        {
            console.log("Prop: " + prop + ", Value: " + currentUser[prop]);
        }
        console.log(currentUser["person_id"]);
    }); 
}
let updateNameCommand = function(id, first, second) {
    let sqlCommand = `UPDATE persons SET person_first = '${first}' WHERE person_id = ${id};`;
    let sqlCommand2 = `UPDATE persons SET person_second = '${second}' WHERE person_id = ${id};`;
                      
    con.query(sqlCommand, function(err, result) {
        if (err) throw err;
        console.log("updated first name!");
    }); 
    con.query(sqlCommand2, function(err, result){
        if (err) throw err;
        console.log("updated last name!");
    })
}
let updatePhoneCommand = function(id, first, second) {
    let sqlCommand = `UPDATE persons SET person_first = '${first}' WHERE person_id = ${id};`;
    let sqlCommand2 = `UPDATE persons SET person_second = '${second}' WHERE person_id = ${id};`;
                      
    con.query(sqlCommand, function(err, result) {
        if (err) throw err;
        console.log("updated first name!");
    }); 
    con.query(sqlCommand2, function(err, result){
        if (err) throw err;
        console.log("updated last name!");
    })
}

    function twoDigits(d) {
        if (0 <= d && d < 10) return "0" + d.toString();
        if (-10 < d && d < 0) return "-0" + (-1 * d).toString();
        return d.toString();
    }

    /**
     * …and then create the method to output the date string as desired.
     * Some people hate using prototypes this way, but if you are going
     * to apply this to more than one Date object, having it as a prototype
     * makes sense.
     **/
    Date.prototype.toMysqlFormat = function () {
        return this.getUTCFullYear() + "-" + twoDigits(1 + this.getUTCMonth()) + "-" + twoDigits(this.getUTCDate()) + " " + twoDigits(this.getUTCHours()) + ":" + twoDigits(this.getUTCMinutes()) + ":" + twoDigits(this.getUTCSeconds());
    }

let update = function(column, id, propertyName, newValue)
{
    let tableName = column + "s";
    let sqlCommand = `UPDATE ${tableName} SET ${propertyName} = '${newValue}' WHERE ${column}_id = ${id};`;
    con.query(sqlCommand, function (err, result) {
        if (err) throw err;
        console.log(`updated ${propertyName} in ${column}!`);
    }); 
}
let personSave = function(id, first, second, gender, phone, email, birthday, height, weight)
{

    let sqlCommand = `INSERT INTO persons (person_id, person_first, person_second, person_gender, person_phone, person_email, person_birthday, person_height, person_weight) VALUES ('${id}', '${first}', '${second}', '${gender}', '${phone}', '${email}','${birthday}',' ${height}', '${weight}');`;
    con.query(sqlCommand, function (err, result) {
        if (err) throw err;
        console.log(`added new person!`);
    }); 
}

    personSave(10, "John", "Johnson", "None", "304-888-1800", "amkhokargmail.com", new Date('December 17, 1995 03: 24: 00').toMysqlFormat(), 120, 180);
});
