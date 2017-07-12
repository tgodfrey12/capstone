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
}
