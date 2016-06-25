/// <vs SolutionOpened='watchsass' />
// This file in the main entry point for defining grunt tasks and using grunt plugins.
// Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409

module.exports = function (grunt) {
    grunt.initConfig({
        sass: {
            options: {
                sourceMap: true
            },
            site: {
                files: {
                    "css/site.css": "sass/site.scss"
                }
            }
        },
        watch: {
            sass: {
                files: ["sass/**/*.scss"],
                tasks: ["compilecss"]
            }
        },
        autoprefixer: {
            options: {
                map: true
            },
            site: {
                src: 'css/site.css',
                dest: 'css/site.css'
            }
        }
    });

    // This command registers the default task which will install bower packages into lib
    grunt.registerTask("watchsass", ["compilecss", "watch:sass"]);
    grunt.registerTask("compilecss", ["sass", "autoprefixer"]);

    // The following line loads the grunt plugins.
    // This line needs to be at the end of this this file.
    grunt.loadNpmTasks("grunt-contrib-watch");
    grunt.loadNpmTasks("grunt-sass");
    grunt.loadNpmTasks("grunt-autoprefixer");
};