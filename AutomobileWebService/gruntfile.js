module.exports = function (grunt) {
    'use strict';

    // Project configuration.
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),

        watch: {
            sass: {
                files: "app/scss/*.scss",
                tasks: ['sass']
            }
        },
        // Sass
        sass: {
            options: {
                sourceMap: true, // Create source map
                outputStyle: 'compressed' // Minify output
            },
            dist: {
                files: [
                    {
                        expand: true, // Recursive
                        cwd: "Styles", // The startup directory
                        src: ["**/*.scss"], // Source files
                        dest: "wwwroot/css", // Destination
                        ext: ".css" // File extension
                    }
                ]
            }
        }
    });

    // Load the plugin
    grunt.loadNpmTasks('grunt-sass');
    //grunt.loadNpmTasks('grunt-contrib-sass');
    grunt.loadNpmTasks('grunt-contrib-watch');

    // Default task(s).
    grunt.registerTask('default', ['sass']);
};