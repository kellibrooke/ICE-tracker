       $( document ).ready(function() {
        $("#anonymous").click(function() {
            if (this.checked) {
                $("#first-name").val("Anonymous");
                $("#last-name").val("Anonymous");
            }else if (!(this.checked)){
                $("#first-name").val("");
                $("#last-name").val("");
            }

        });

    });
