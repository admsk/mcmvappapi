import React from "react";
import { useAllParticipants, useParticipants } from "../hooks/useParticipants";
import { Link } from "react-router-dom";

const scopes = ["IDOSO", "DEFICIENTE FÍSICO", "GERAL"];

export function Home() {
  const [scope, setScope] = React.useState("IDOSO");

  const { data: allParticipants } = useAllParticipants();
  const { data, isLoading } = useParticipants(scope);

  return (
    <div className="d-flex flex-column">
      <div className="p-5 mb-4 bg-body-tertiary rounded-3">
        <div className="container-fluid py-5">
          <h1 className="display-5 fw-bold">Sorteio de Habitação</h1>
          <p className="col-md-8 fs-4">Listas dos Participantes do Sorteio</p>
        </div>
      </div>

      <div className="d-flex justify-content-between">
        <h1 className="h5">
          Total de participantes: {allParticipants?.length ?? 0}
        </h1>

        <Link to="/ganhadores" className="btn btn-primary">
          Realizar Sorteio
        </Link>
      </div>

      <ul className="nav nav-tabs">
        {scopes.map((s) => (
          <li className="nav-item" key={s}>
            <button
              onClick={() => setScope(s)}
              className={`nav-link ${scope === s ? "active" : ""}`}
              aria-current="page"
              href="#"
            >
              {s}
            </button>
          </li>
        ))}
      </ul>

      {isLoading && (
        <div className="spinner-border mx-auto my-4" role="status">
          <span className="visually-hidden">Loading...</span>
        </div>
      )}

      <table className="table">
        <thead>
          <tr>
            <th scope="col">CPF</th>
            <th scope="col">NOME</th>
          </tr>
        </thead>
        <tbody>
          {data?.map((participant) => (
            <tr key={participant.cpf}>
              <td>{participant.cpf}</td>
              <td>{participant.nome}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
