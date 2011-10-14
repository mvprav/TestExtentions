require 'Albacore'
task :default=> [:build]

@build_output='build_output'

msbuild :build do |msb|
	Dir.mkdir(@build_output) unless File.exists?(@build_output)
	msb.solution="TestExtentions.sln"
	msb.properties :configuration=>:Debug
	msb.targets :Clean,:Build
	msb.loggermodule = "FileLogger,Microsoft.Build.Engine;logfile=#{@build_output}/MyLog.log"
end