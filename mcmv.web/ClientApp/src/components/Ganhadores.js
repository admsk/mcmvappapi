import React, { useMemo } from "react";
import { useSorteio } from "../hooks/useParticipants";
import { PieChart, Pie, Cell, Tooltip } from "recharts";

const scopes = ["IDOSO", "DEFICIENTE FÍSICO", "GERAL"];
const COLORS = ["#8884d8", "#82ca9d", "#ffc658"];

export function Ganhadores() {
  const { data: sorteioData, isLoading } = useSorteio();

  const chartData = useMemo(() => {
    return scopes.map((scope) => ({
      name: scope,
      value: sorteioData?.[scope]?.length || 0,
    }));
  }, [sorteioData]);

  return (
    <div className="d-flex flex-column">
      <div className="p-5 mb-4 bg-body-tertiary rounded-3 d-flex" style={{backgroundColor:'aliceblue'}}>
        <div className="container-fluid py-5">
          <h1 className="display-5 fw-bold">Sorteio de Habitação</h1>
          <p className="col-md-8 fs-4">Ganhadores do Sorteio</p>
        </div>

        <PieChart width={400} height={200}>
          <Pie
            data={chartData}
            dataKey="value"
            nameKey="name"
            cx="50%"
            cy="50%"
            outerRadius={100}
            fill="#8884d8"
            label={({ name }) => name}
          >
            {chartData.map((entry, index) => (
              <Cell
                key={`cell-${index}`}
                fill={COLORS[index % COLORS.length]}
              />
            ))}
          </Pie>
          <Tooltip formatter={(value, name) => [`${value} ganhadores`, name]} />
        </PieChart>
      </div>

      {isLoading && (
        <div className="spinner-border mx-auto my-4" role="status">
          <span className="visually-hidden">Loading...</span>
        </div>
      )}

      <div className="d-flex justify-content-between">
        {scopes.map((scope) => (
          <div className="card m-3" key={scope}>
            <div className="card-body">
              <h5 className="card-title">{scope == "GERAL" ? 'Ganhadores' : 'Ganhador'} da Lista {scope}</h5>
              <table className="table">
                <thead>
                  <tr>
                    <th scope="col">CPF</th>
                    <th scope="col">NOME</th>
                  </tr>
                </thead>
                <tbody>
                  {sorteioData?.[scope]?.map((participant) => (
                    <tr key={participant.id}>
                      <td>{participant.cpf}</td>
                      <td>{participant.nome}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}
