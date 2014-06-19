var GetCountViewModel = function () {
    var self = this;
    this.keywords = ko.observable("online title search");
    // https://www.google.com.au/search?num=100&q=online+title+search
    this.url = ko.observable("https://www.google.com.au");
    this.getResult = function (e) {
        $.post('/api/data/get_count', { keywords: self.keywords, url: self.url }, function (data) {
            e.preventDefault();
            $('#loading').show();
            $('#result').hide();
            $('#error').hide();
            if (response.success) {
                $('#result span').text(response.data);
                $('#result').show();
            } else {
                $('#error span').text(response.message);
                $('#error').show();
            }
        }, 'json')
        .error(function () {
            $('#error span').text('Server internal error');
            $('#error').show();
        }).always(function () {
            $('#loading').hide();
        });
    };
};

$(function () {
    ko.applyBindings(new GetCountViewModel());
});