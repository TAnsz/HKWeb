seajs.config({
  alias: {
      'jquery': 'jquery-1.10.2.min.js',
      'jqprint': 'jquery.jqprint-0.3.js',
      'jqmigrate': 'jquery-migrate-1.2.1.min.js',
      'form': 'plugin/jquery.form.js',
      'datepicker': 'plugin/jquery.datepicker.js',
      'validate': 'plugin/jquery.validate.js',
      'dropdown': 'plugin/jquery.dropdown.js',
      'dailog': 'plugin/jquery.ifrmdailog.js'          
  },
  preload: [
   'jquery',
   'common'
  ],
  debug: true,
  map: [
    [/^(.*\/Js\/page\/.*\.(?:js))(?:.*)$/i, '$1?2016031502'],
    [/^(.*\/Js\/plugin\/.*\.(?:js))(?:.*)$/i, '$1?2016031502']
  ],
  charset: 'utf-8',
  timeout: 20000
});