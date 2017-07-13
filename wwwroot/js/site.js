// Write your Javascript code.
//alert("this message is from site.js");

(function() {
    $(document).ready(function() {
        
        setupListeners();
    });
})();   

function setupListeners(){

    var catsAndClasses = {
        'Academics': ['elementary science', 'middle grades science', 'chemistry', 'history', 'writing', 'reading'],
        'Languages': ['japanese', 'german', 'french', 'spanish', 'english'],
        'Mathematics': ['precalculus', 'algebra 2', 'geometry', 'algebra 1', 'middle school math'],
        'SAT Test Prep': ['mathematics level 1', 'mathematics level 2']
    }
    
    var $catsAndClasses = $('#classNames');
    $('#category').change(function () {
        var cat = $(this).val(), lcns = catsAndClasses[cat] || [];
        
        var html = $.map(lcns, function(lcn){
            return '<option value="' + lcn + '">' + lcn + '</option>'
        }).join('');
        $catsAndClasses.html(html)


    });

    $('#submitNewClassBtn').click(function (){
        let newClassCategory = $('#category').val();
        let requestClassName = $('#classNames').val();
        let classID = 0;

        switch(requestClassName){
            case 'guitar':
                classID = 2;
                break;
            case 'economics':
                classID = 3;
                break;
            case 'personal finance':
                classID = 4;
                break;
            case 'excel':
                classID = 5;
                break;
            case 'accounting':
                classID = 6;
                break;
            case 'elementary science':
                classID = 7;
                break;
            case 'middle grades science':
                classID = 8;
                break;
            case 'chemistry':
                classID = 9;
                break;
            case 'history':
                classID = 10;
                break;
            case 'writing':
                classID = 11;
                break;
            case 'reading':
                classID = 12;
                break;
            case 'japanese':
                classID = 13;
                break;
            case 'german':
                classID = 14;
                break;
	        case 'french':
	            classID = 15;
	            break;
	        case 'spanish':
	            classID = 16;
	            break;
	        case 'english':
	            classID = 17;
	            break;
	        case 'calculus':
	            classID = 18;
	            break;
	        case 'precalculus':
	            classID = 19;
	            break;
	         case 'algebra 2':
	            classID = 20;
	            break;
	        case 'geometry':
	            classID = 21;
	            break;
	         case 'algebra 1':
	            classID = 22;
	            break;
             case 'middle school math':
                classID = 23;
                break;
             case 'double bass':
                classID = 24;
                break;
             case 'violin':
                classID = 25;
                break;
             case 'bass guitar':
                classID = 26;
                break;
             case 'trombone':
                classID = 27;
                break;
             case 'trumpet':
                classID = 28;
                break;
             case 'piano':
                classID = 29;
                break;
             case 'mathematics level 1':
                classID = 30;
                break;
             case 'mathematics level 2':
                classID = 31;
                break;

                }


        sendClassRequest(classID);
    })

    //React to the button being pushed

}


function sendClassRequest(classID){

    console.log("In sendClassRequest " + classID)
    var loc = document.location;

    //Get the student ID from the URL
    let locAra = loc.href.split('/');
    insertStudentClass(locAra[5], classID)
}

function insertStudentClass(studentID, classID){
    //Try to call http://localhost:52461/Students/StudentClasses/4


//    $.post( "http://localhost:52461/Students/insertStudentClass", function( data ) {
//  $( ".result" ).html( data );
//});

$.post('http://localhost:52461/Students/insertStudentClass', { studentID: studentID, classID : classID}, 
    function(returnedData){
         console.log(returnedData);
});


};

//An example Ajax call
//  function getResults(searchTerm) {
//      var request = $.ajax({
//          url: "https://api.spotify.com/v1/search",
//          method: "GET",
//          data: {
//              q: "artist:" + searchTerm,
//              type: "album",
//              limit: 5
//          },
//          dataType: "json",
//      });

//    results.done(function(response) {



//        var albums = response.albums.items;
//        var display = ""
//        $.each(albums, function(i, album) {
//            var albumName = album.name;
//            var albumImage = album.images[0].url;
//            var spotifyLink = album.external_urls.spotify;
//            display += "<li><img src=" + albumImage + "></li>";
//        });
//        $('.results').html(display);
//    });

//    results.fail(function(error) {
//        alert("Something went wrong!");
//    })
//};