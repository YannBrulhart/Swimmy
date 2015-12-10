module.exports = function (grunt) {
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),

        // Copy web assets from bower_components to more convenient directories.
        copy: {
            main: {
                files: [
                    // Vendor scripts.
                    {
                        expand: true,
                        cwd: 'bower_components/bootstrap/dist/js/',
                        src: ['**/*.js'],
                        dest: 'scripts/bootstrap/'
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/jquery/dist/',
                        src: ['**/*.js', '**/*.map'],
                        dest: 'scripts/jquery/'
                    },

                    // Fonts.
                    {
                        expand: true,
                        filter: 'isFile',
                        flatten: true,
                        cwd: 'bower_components/',
                        src: ['/bootstrap/dist/fonts/**'],
                        dest: 'fonts/'
                    },

                    // Stylesheets
                    {
                        expand: true,
                        cwd: 'bower_components/bootstrap/dist/css/',
                        src: ['**/*.css', '**/*.map'],
                        dest: 'Content/css/'
                    }
                ]
            }
        },

        // Watch these files and notify of changes.
        watch: {
            grunt: { files: ['Gruntfile.js'] }
        }
    });

    // Load externally defined tasks. 
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-copy');

    // Establish tasks we can run from the terminal.
    grunt.registerTask('build', ['copy']);
    grunt.registerTask('default', ['build', 'watch']);
}