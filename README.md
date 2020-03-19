## Client


```bash
python -m SimpleHTTPServer

wrk -t2 -d20s https://localhost:5001/api/google/fetch
wrk -t2 -d20s https://localhost:5001/api/google/fetch2

netstat -na | grep 8000
netstat -na | grep 8000 | wc -l
```
