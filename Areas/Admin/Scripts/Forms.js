$(document).ready(function() {
    $("a[data-post]").click(function(e) {
        e.preventDefault();

        var $this = $(this);
        var message = $this.data("post");

        if (message && !confirm(message))
            return;

        var antiForgeryToken = $("#anti-forgery-form input");
        var antiForgeryInput = $("<input type='hidden'>").attr("name", antiForgeryToken.attr("name")).val(antiForgeryToken.val());

        $("<form>")
            .attr("method", "post")
            .attr("action", $this.attr("href"))
            .append(antiForgeryInput)
            .appendTo(document.body)
            .submit();
    });

    $("[data-slug]").each(function() {                 //looping through everything that has data slug attribute on it
        var $this = $(this);
        var $sendSlugFrom = $($this.data("slug"));  //locate text field where we are getting slug from

        $sendSlugFrom.keyup(function() {   //attach event handler: everytime a key is pressed a slug is produced
            var slug = $sendSlugFrom.val();
            slug = slug.replace(/[^a-zA-Z0-9\s]/g, ""); //gets rid of all special charachters
            slug = slug.toLowerCase(); //replace to lower case
            slug = slug.replace(/\s+/g, "-"); //finds instance of one ore more spaces and replaces with a dash


            if (slug.charAt(slug.length - 1) == "-") //check if final characther is a dash
                slug = slug.substr(0, slug.length - 1); //if it is trim final charachter

            $this.val(slug); //update value to equal slug
        })
    })
});