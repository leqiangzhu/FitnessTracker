$(document).ready(function () {
  $('.menu-link').bigSlide();
  $('#horizontalTab').easyResponsiveTabs({
   type: 'default', //Types: default, vertical, accordion
   width: 'auto', //auto or any width like 600px
   fit: true // 100% fit in a container
 });
});
