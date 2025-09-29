loadResource()

function loadResource()
{
    if(fs.existsSync(resourceFilePath))
    {
        const data = fs.readFileSync(resourceFilePath);
        global.players = JSON.parse(data);
    }
    else
    {
        global.players = {};
    }


}

function saveResources()
{
    fs.writeFileSync(resourceFilePath, JSON.stringify(global.players, null, 2));
}
app.listen(port, ()=>
{
    console.log('서버가 http://localhost:${port}에서 실행 중 입니다.');
})