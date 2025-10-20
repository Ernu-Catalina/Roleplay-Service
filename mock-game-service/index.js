const express = require('express');
const app = express();
const port = 3005;

app.use(express.json());

// Simple mock state for demo
let playerStatuses = {
  123: "alive",
  456: "alive"
};

// ✅ GET endpoint: get player status
app.get('/game/:id/status', (req, res) => {
  const id = req.params.id;
  const status = playerStatuses[id];
  if (!status) {
    return res.status(404).json({ error: "not found" });
  }
  res.json({ status });
});

// ✅ POST endpoint: update player status
app.post('/game/:id/status', (req, res) => {
  const id = req.params.id;
  const { status } = req.body;
  playerStatuses[id] = status;
  console.log(`Updated player ${id} to status: ${status}`);
  res.json({ success: true, id, new_status: status });
});

// (Optional legacy route — safe to remove)
app.post('/update-status', (req, res) => {
  console.log('Received update-status:', req.body);
  res.json({ success: true });
});

app.listen(port, () => {
  console.log(`✅ Mock Game Service running on port ${port}`);
});
