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

        var acc = document.getElementsByClassName("accordion");
        var i;

        for (i = 0; i < acc.length; i++) {
            acc[i].addEventListener("click", function() {
                /* Toggle between adding and removing the "active" class,
                to highlight the button that controls the panel */
                this.classList.toggle("active");

                /* Toggle between hiding and showing the active panel */
                var panel = this.nextElementSibling;
                if (panel.style.display === "block") {
                    panel.style.display = "none";
                } else {
                    panel.style.display = "block";
                }
            });
        }

    });


