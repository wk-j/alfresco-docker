
Action<string,string> process = (c, args) => {
    StartProcess(c, new ProcessSettings {
        Arguments = args
    });
};

Task("Compose-Up").Does(() => {
    process("docker-compose", "up -d --build");
});

Task("Remove-All").Does(() => {
    //docker stop $(docker ps -a -q)
    //docker rm $(docker ps -a -q)
    process("docker", "stop $(docker ps -a -q)");
    process("docker", "rm $(docker ps -a -q)");
});

var target = Argument("target", "default");
RunTarget(target);