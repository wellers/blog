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