$(".disabled-link").click(function (event) {
	event.preventDefault();
});

// Home view javascript functions
var Home = (function () {
	var setActiveNav = function() {
		var $nav = $("#navMenu a[href='" + window.location.pathname + "']");
		if ($nav.length > 0) {
			$nav.parent().addClass('active');
		} else {
			$("#navMenu a[href='/']").parent().addClass('active');
		}
	};
	
	return {
		setActiveNav: setActiveNav
	};
})();

// SetTheme view javascript functions
var SetTheme = (function () {
	var setSelectedTheme = function(theme) {
		$('#SelectedTheme option').removeAttr('selected');
		var $selectedOption = $('#SelectedTheme option:contains("' + theme + '")');
		$selectedOption.attr('selected', 'selected');
		$('.bootstrap-select .filter-option').text($selectedOption.text());
	};
	return {
		setSelectedTheme: setSelectedTheme
	};
})();

// TwitterFeed javascript functions
var TwitterFeed = (function () {
	var monthNames = ["January", "February", "March", "April", "May", "June",
		"July", "August", "September", "October", "November", "December"];

	var loadLatestTweet = function (username, feedItemCount) {
		var url = 'https://api.twitter.com/1/statuses/user_timeline/'
			+ username + '.json?callback=?&count=' + feedItemCount;
		$.getJSON(url, function (data) {
			var output = "";
			for (var i = 0; i < feedItemCount; i++) {
				output += formatTweet(data[i], username);
			}

			var contents = '<table class="table table-bordered">' +
								'<thead><tr class="tweetsRow">' +
										'<th><h4 style="margin-left: 25px;">My Recent Tweets</h4></th>' +
								'</tr></thead>';
			contents += '<tbody>' + output + '</tbody></table>';
			$("#TwitterFeed").html(contents);
		});
	};

	var formatTweet = function (tweet) {
		var created = parseDate(tweet.created_at);
		var createdDate = created.getDate() + ' ' + (monthNames[created.getMonth()]) + ' ' + created.getFullYear();
		var tweetRow = '<tr class="tweetsRow">' +
							'<td><p style="display: inline;"><small>' +
							tweet.text.parseURL().parseUsername().parseHashtag() + '</small></p>' +
							'<p class="tweetDate"><small>' + createdDate + '</small></p></td></tr>';
		return tweetRow;
	};

	// Creates an anchor tag with a target of "_blank"
	String.prototype.blankLink = function(url, text) {
		return "<a target='_blank' href='" + url + "'>" + text + "</a>";
	};

	/* Twitter Parsers */	
	String.prototype.parseURL = function () {
		return this.replace(/[A-Za-z]+:\/\/[A-Za-z0-9-_]+\.[A-Za-z0-9-_:%&~\?\/.=]+/g, function (url) {
			return url.blankLink(url, url);
		});
	};
	
	String.prototype.parseUsername = function () {
		return this.replace(/[@]+[A-Za-z0-9-_]+/g, function (u) {
			var username = u.replace("@", "");
			return u.blankLink("http://twitter.com/" + username, u);
		});
	};
	
	String.prototype.parseHashtag = function () {
		return this.replace(/[#]+[A-Za-z0-9-_]+/g, function (t) {
			var tag = t.replace("#", "%23");
			return t.blankLink("http://twitter.com/search?q=" + tag, t);
		});
	};
	
	function parseDate(str) {
		var v = str.split(' ');
		return new Date(Date.parse(v[1] + " " + v[2] + ", " + v[5] + " " + v[3] + " UTC"));
	}

	return {
		loadLatestTweet: loadLatestTweet
	};
})();